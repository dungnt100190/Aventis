CREATE TABLE [dbo].[BaZahlungsweg_Backup](
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
	[IsZkbVmKonto] [bit] NULL,
	[WMAVerwenden] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON