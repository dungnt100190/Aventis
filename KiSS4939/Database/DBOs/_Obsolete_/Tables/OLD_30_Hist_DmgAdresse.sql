CREATE TABLE [dbo].[OLD_30_Hist_DmgAdresse](
	[DmgAdresseID] [int] NOT NULL,
	[AdressZusatz] [varchar](200) NULL,
	[Strasse] [varchar](100) NULL,
	[Nummer] [varchar](10) NULL,
	[Postfach] [varchar](100) NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[Kanton] [varchar](10) NULL,
	[LandCode] [int] NULL,
	[OrtschaftCode] [int] NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_DmgAdresse] PRIMARY KEY CLUSTERED 
(
	[DmgAdresseID] ASC,
	[VerID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO