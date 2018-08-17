CREATE TABLE [dbo].[KbKonto](
	[KbKontoID] [int] IDENTITY(1,1) NOT NULL,
	[KbPeriodeID] [int] NULL,
	[GruppeKontoID] [int] NULL,
	[Kontogruppe] [bit] NOT NULL,
	[KbKontoklasseCode] [int] NULL,
	[KbKontoartCodes] [varchar](20) NULL,
	[KontoNr] [varchar](10) NOT NULL,
	[KontoName] [varchar](100) NOT NULL,
	[Vorsaldo] [money] NOT NULL,
	[SaldoGruppeName] [varchar](100) NULL,
	[Saldovortrag] [bit] NULL,
	[KbKontoTS] [timestamp] NOT NULL,
	[SortKey] [int] NULL,
	[KbZahlungskontoID] [int] NULL,
 CONSTRAINT [PK_KbKonto] PRIMARY KEY NONCLUSTERED 
(
	[KbKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_KbKonto] UNIQUE CLUSTERED 
(
	[KbPeriodeID] ASC,
	[KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbKonto Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbKonto', @level2type=N'COLUMN',@level2name=N'KbKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbKonto_KbPeriode) => KbPeriode.KbPeriodeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbKonto', @level2type=N'COLUMN',@level2name=N'KbPeriodeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KbKonto_KbZahlungskonto) => KbZahlungskonto.KbZahlungskontoID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbKonto', @level2type=N'COLUMN',@level2name=N'KbZahlungskontoID'
GO

ALTER TABLE [dbo].[KbKonto]  WITH CHECK ADD  CONSTRAINT [FK_KbKonto_KbKonto] FOREIGN KEY([GruppeKontoID])
REFERENCES [dbo].[KbKonto] ([KbKontoID])
GO

ALTER TABLE [dbo].[KbKonto] CHECK CONSTRAINT [FK_KbKonto_KbKonto]
GO

ALTER TABLE [dbo].[KbKonto]  WITH CHECK ADD  CONSTRAINT [FK_KbKonto_KbPeriode] FOREIGN KEY([KbPeriodeID])
REFERENCES [dbo].[KbPeriode] ([KbPeriodeID])
GO

ALTER TABLE [dbo].[KbKonto] CHECK CONSTRAINT [FK_KbKonto_KbPeriode]
GO

ALTER TABLE [dbo].[KbKonto]  WITH CHECK ADD  CONSTRAINT [FK_KbKonto_KbZahlungskonto] FOREIGN KEY([KbZahlungskontoID])
REFERENCES [dbo].[KbZahlungskonto] ([KbZahlungskontoID])
GO

ALTER TABLE [dbo].[KbKonto] CHECK CONSTRAINT [FK_KbKonto_KbZahlungskonto]
GO

ALTER TABLE [dbo].[KbKonto] ADD  CONSTRAINT [DF_KbKonto_Vorsaldo]  DEFAULT (0) FOR [Vorsaldo]
GO