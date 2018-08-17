CREATE TABLE [dbo].[KaEinsatzplatz2] (
	[KaEinsatzplatzID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (100) NOT NULL ,
	[ProjektCode] [int] NOT NULL ,
	[ProfilCode] [int] NULL ,
	[APVCode] [int] NULL ,
	[DatumVon] [datetime] NOT NULL ,
	[DatumBis] [datetime] NULL ,
	[KaEinsatzplatz2TS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaEinsatzplatz2] PRIMARY KEY  Clustered
	(
		[KaEinsatzplatzID]
	)  ON [DATEN2]
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KaEinsatzplatz2_Name] ON [dbo].[KaEinsatzplatz2]([Name]) ON [DATEN2]
GO
EXEC sp_addextendedproperty N'Author', N'Leonhard Greulich', N'user', N'dbo', N'table', N'KaEinsatzplatz2'
GO
EXEC sp_addextendedproperty N'Customer_only', N'Kunde ist Kompetenzzentrum für Arbeit (KA). KiSS wird zusammen mit SD Bern benutzt.', N'user', N'dbo', N'table', N'KaEinsatzplatz2'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Liste der Einsatzplätze mit DatumVon - DatumBis', N'user', N'dbo', N'table', N'KaEinsatzplatz2'
GO
EXEC sp_addextendedproperty N'Used_in', N'Modul KA', N'user', N'dbo', N'table', N'KaEinsatzplatz2'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaEinsatzplatz2 Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'KaEinsatzplatzID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Bezeichnung des Einsatzplatzes', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'Name'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaProjekt', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'ProjektCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaProfil', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'ProfilCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaAPV', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'APVCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'DatumVon des Einsatzplatzes', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'DatumVon'
GO
EXEC sp_addextendedproperty N'Remarks', N'Wird für Auswahlfelder benutzt damit nur gültige Werte ausgewählt werden können.', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'DatumVon'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'DatumBis des Einsatzplatzes', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'DatumBis'
GO
EXEC sp_addextendedproperty N'Remarks', N'Wird für Auswahlfelder benutzt damit nur gültige Werte ausgewählt werden können.', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'DatumBis'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp für Tabelle KaEinsatzplatz2', N'user', N'dbo', N'table', N'KaEinsatzplatz2', N'column', N'KaEinsatzplatz2TS'
GO

GO
