CREATE TABLE [dbo].[Import_BC_Bankenstamm] (
	[Bankengruppe] [int] NOT NULL ,
	[BC_Nummer] [int] NOT NULL ,
	[Filial_ID] [varchar] (4) NOT NULL ,
	[BC_Nummer_neu] [int] NULL ,
	[SIC_Nummer] [varchar] (6) NULL ,
	[Hauptsitz] [int] NULL ,
	[BC_Art] [int] NULL ,
	[Datum] [datetime] NULL ,
	[Teilnahmecode_CHF] [int] NULL ,
	[Teilnahmecode_EUR] [int] NULL ,
	[SprachCode] [int] NULL ,
	[Kurzbezeichnung] [varchar] (15) NULL ,
	[Bank_Institut] [varchar] (60) NULL ,
	[Domizil_Quartier] [varchar] (35) NULL ,
	[Postadresse] [varchar] (35) NULL ,
	[PLZ] [varchar] (10) NULL ,
	[Ort] [varchar] (35) NULL ,
	[Telefon] [varchar] (18) NULL ,
	[Fax] [varchar] (18) NULL ,
	[Landes_Vorwahl] [varchar] (5) NULL ,
	[LandCode] [varchar] (2) NULL ,
	[Postkonto] [varchar] (12) NULL ,
	[SWIFT] [varchar] (14) NULL ,
	CONSTRAINT [PK_Import_BC_Bankenstamm] PRIMARY KEY  Clustered
	(
		[Bankengruppe],
		[BC_Nummer],
		[Filial_ID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für Import_BC_Bankenstamm Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'Import_BC_Bankenstamm', N'column', N'Bankengruppe'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für Import_BC_Bankenstamm Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'Import_BC_Bankenstamm', N'column', N'BC_Nummer'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für Import_BC_Bankenstamm Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'Import_BC_Bankenstamm', N'column', N'Filial_ID'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
