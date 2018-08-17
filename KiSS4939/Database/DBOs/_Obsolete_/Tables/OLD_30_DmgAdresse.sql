CREATE TABLE [dbo].[OLD_30_DmgAdresse](
	[DmgAdresseID] [int] IDENTITY(1,1) NOT NULL,
	[AdressZusatz] [varchar](200) NULL,
	[Strasse] [varchar](100) NULL,
	[Nummer] [varchar](10) NULL,
	[Postfach] [varchar](100) NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[Kanton] [varchar](10) NULL,
	[LandCode] [int] NULL,
	[OrtschaftCode] [int] NULL,
	[DmgAdresseTS] [timestamp] NOT NULL,
	[VerID] [int] NULL,
 CONSTRAINT [PK_DmgAdresse] PRIMARY KEY CLUSTERED 
(
	[DmgAdresseID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO