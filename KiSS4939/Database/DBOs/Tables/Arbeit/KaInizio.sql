CREATE TABLE [dbo].[KaInizio] (
	[KaInizioID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NULL ,
	[MappeVerschickt] [datetime] NULL ,
	[AnmeldungEingegangen] [datetime] NULL ,
	[AnmeldungDurchCode] [int] NULL ,
	[SchulabschlussCode] [int] NULL ,
	[EmpfehlungInizioCode] [int] NULL ,
	[AbschlussPhaseCode] [int] NULL ,
	[KaInizioTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaInizio] PRIMARY KEY  Clustered
	(
		[KaInizioID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_KaInizio_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KaInizio_FaLeistungID] ON [dbo].[KaInizio]([FaLeistungID]) ON [DATEN2]
GO
EXEC sp_addextendedproperty N'Author', N'Leonhard Greulich', N'user', N'dbo', N'table', N'KaInizio'
GO
EXEC sp_addextendedproperty N'Customer_only', N'Kunde ist Kompetenzzentrum f�r Arbeit (KA). KiSS wird zusammen mit SD Bern benutzt.', N'user', N'dbo', N'table', N'KaInizio'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Eintr�ge f�r Phase Inizio', N'user', N'dbo', N'table', N'KaInizio'
GO
EXEC sp_addextendedproperty N'Used_in', N'Modul KA', N'user', N'dbo', N'table', N'KaInizio'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Prim�rschl�ssel f�r KaInizio Records (nach Prim�rschl�ssel-Standards)', N'user', N'dbo', N'table', N'KaInizio', N'column', N'KaInizioID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschl�ssel (FK_KaInizio_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'KaInizio', N'column', N'FaLeistungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Datum Mappe verschickt', N'user', N'dbo', N'table', N'KaInizio', N'column', N'MappeVerschickt'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Datum Anmeldung eingegangen', N'user', N'dbo', N'table', N'KaInizio', N'column', N'AnmeldungEingegangen'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaInizioAnmeldungDurch', N'user', N'dbo', N'table', N'KaInizio', N'column', N'AnmeldungDurchCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaInizioSchulabschluss', N'user', N'dbo', N'table', N'KaInizio', N'column', N'SchulabschlussCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaInizioAusbildungEmpfehlung', N'user', N'dbo', N'table', N'KaInizio', N'column', N'EmpfehlungInizioCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Code aus Werteliste KaInizioAbschlussPhase1', N'user', N'dbo', N'table', N'KaInizio', N'column', N'AbschlussPhaseCode'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp f�r Tabelle KaInizio', N'user', N'dbo', N'table', N'KaInizio', N'column', N'KaInizioTS'
GO

GO
