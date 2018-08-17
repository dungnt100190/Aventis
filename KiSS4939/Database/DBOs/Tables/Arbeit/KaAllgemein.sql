CREATE TABLE [dbo].[KaAllgemein] (
	[KaAllgemeinID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[KaAllgemeinTS] [timestamp] NOT NULL ,
	[SichtbarSDFlag] [bit] NOT NULL CONSTRAINT [DF__KaAllgeme__Sicht__0EA65E45] DEFAULT (0),
	CONSTRAINT [PK_KaAllgemein] PRIMARY KEY  Clustered
	(
		[KaAllgemeinID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_KaAllgemein_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_KaAllgemein_FaLeistungID] ON [dbo].[KaAllgemein]([FaLeistungID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaAllgemein Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaAllgemein', N'column', N'KaAllgemeinID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaAllgemein_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'KaAllgemein', N'column', N'FaLeistungID'
GO

GO

GO

GO

GO

GO

GO

GO
