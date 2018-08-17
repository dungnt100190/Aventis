CREATE TABLE [dbo].[KaZuteilFachbereich] (
	[KaZuteilFachbereichID] [int] IDENTITY (1, 1) NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[ZuteilungVon] [datetime] NULL ,
	[ZuteilungBis] [datetime] NULL ,
	[FachbereichID] [int] NULL ,
	[NiveauCode] [int] NULL ,
	[ZustaendigKaID] [int] NULL ,
	[FachleitungID] [int] NULL ,
	[ZuteilDokID] [int] NULL ,
	[SichtbarSDFlag] [bit] NOT NULL CONSTRAINT [DF__KaZuteilF__Sicht__1C005963] DEFAULT (0),
	[KaZuteilFachbereichTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaZuteilFachbereich] PRIMARY KEY  Clustered
	(
		[KaZuteilFachbereichID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_KaZuteilFachbereich_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KaZuteilFachbereich_BaPersonID] ON [dbo].[KaZuteilFachbereich]([BaPersonID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaZuteilFachbereich Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaZuteilFachbereich', N'column', N'KaZuteilFachbereichID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaZuteilFachbereich_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'KaZuteilFachbereich', N'column', N'BaPersonID'
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
