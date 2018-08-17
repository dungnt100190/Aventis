CREATE TABLE [dbo].[MigZahlungsweg](
	[BaZahlungswegID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[EinzahlungsscheinCode] [int] NULL,
	[ZahlinformationAktiv] [bit] NULL,
	[BaBankID] [int] NULL,
	[BankKontoNummer] [varchar](50) NULL,
	[IBANNummer] [varchar](50) NULL,
	[PostKontoNummer] [varchar](20) NULL,
	[ESRTeilnehmer] [varchar](100) NULL,
	[Adresszeile1] [varchar](100) NULL,
	[Adresszeile2] [varchar](100) NULL,
	[Adresszeile3] [varchar](100) NULL,
	[Adresszeile4] [varchar](100) NULL,
	[BaZahlungswegTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_MigZahlungsweg] PRIMARY KEY CLUSTERED 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON