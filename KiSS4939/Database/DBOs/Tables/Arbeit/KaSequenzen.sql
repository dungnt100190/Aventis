CREATE TABLE [dbo].[KaSequenzen] (
	[KaSequenzenID] [int] IDENTITY (1, 1) NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[SequenzCode] [int] NULL ,
	[PraesenzCode] [int] NULL ,
	[SichtbarSDFlag] [bit] NOT NULL CONSTRAINT [DF__KaSequenz__Sicht__647B1A4F] DEFAULT (0),
	[KaSequenzenTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaSequenzen] PRIMARY KEY  Clustered
	(
		[KaSequenzenID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_KaSequenzen_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_KaSequenzen_BaPersonID] ON [dbo].[KaSequenzen]([BaPersonID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaSequenzen Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaSequenzen', N'column', N'KaSequenzenID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaSequenzen_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'KaSequenzen', N'column', N'BaPersonID'
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
