CREATE TABLE [dbo].[KbBelegKreis] (
	[KbBelegKreisID] [int] IDENTITY (1, 1) NOT NULL ,
	[KbPeriodeID] [int] NOT NULL ,
	[KbBelegKreisCode] [int] NOT NULL ,
	[KontoNr] [varchar] (10) NULL ,
	[NaechsteBelegNr] [int] NULL ,
	[BelegNrVon] [int] NULL ,
	[BelegNrBis] [int] NULL ,
	[KbBelegKreisTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbBelegKreis] PRIMARY KEY  Clustered
	(
		[KbBelegKreisID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_KbBelegKreis_KbKonto] FOREIGN KEY
	(
		[KbPeriodeID],
		[KontoNr]
	) REFERENCES [dbo].[KbKonto] (
		[KbPeriodeID],
		[KontoNr]
	),
	CONSTRAINT [FK_KbBelegKreis_KbPeriode] FOREIGN KEY
	(
		[KbPeriodeID]
	) REFERENCES [dbo].[KbPeriode] (
		[KbPeriodeID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbBelegKreis_KbPeriodeID] ON [dbo].[KbBelegKreis]([KbPeriodeID]) ON [DATEN3]
GO
 CREATE  Unique  INDEX [IX_KbBelegKreis_KbBelegKreisKbPeriodeIDKontoNr_Unique] ON [dbo].[KbBelegKreis]([KbPeriodeID], [KbBelegKreisCode], [KontoNr]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbBelegKreis Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbBelegKreis', N'column', N'KbBelegKreisID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbBelegKreis_KbPeriode) => KbPeriode.KbPeriodeID', N'user', N'dbo', N'table', N'KbBelegKreis', N'column', N'KbPeriodeID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbBelegKreis_KbKonto) => KbKonto.KontoNr', N'user', N'dbo', N'table', N'KbBelegKreis', N'column', N'KontoNr'
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
