CREATE TABLE [dbo].[KaKurserfassung] (
	[KaKurserfassungID] [int] IDENTITY (1, 1) NOT NULL ,
	[KursID] [int] NOT NULL ,
	[KursNr] [varchar] (25) NULL ,
	[DatumVon] [datetime] NULL ,
	[DatumBis] [datetime] NULL ,
	[SistiertFlag] [bit] NOT NULL CONSTRAINT [DF__KaKurserf__Sisti__08ED84EF] DEFAULT (0),
	[KaKurserfassungTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaKurserfassung] PRIMARY KEY  Clustered
	(
		[KaKurserfassungID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_KaKurserfassung_KaKurs] FOREIGN KEY
	(
		[KursID]
	) REFERENCES [dbo].[KaKurs] (
		[KaKursID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KaKurserfassung_KursID] ON [dbo].[KaKurserfassung]([KursID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaKurserfassung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaKurserfassung', N'column', N'KaKurserfassungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaKurserfassung_KaKurs) => KaKurs.KaKursID', N'user', N'dbo', N'table', N'KaKurserfassung', N'column', N'KursID'
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
