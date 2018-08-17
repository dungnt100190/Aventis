CREATE TABLE [dbo].[KaAKZuweiser] (
	[KaAKZuweiserID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[Erfassung] [datetime] NULL ,
	[AnmeldungCode] [int] NULL ,
	[InstitutionID] [int] NULL ,
	[BeraterID] [int] NULL ,
	[SichtbarSDFlag] [bit] NOT NULL CONSTRAINT [DF__KaAKZuwei__Sicht__507421A2] DEFAULT (0),
	[KaAKZuweiserTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaAKZuweiser] PRIMARY KEY  Clustered
	(
		[KaAKZuweiserID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_KaAKZuweiser_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KaAKZuweiser_FaLeistungID] ON [dbo].[KaAKZuweiser]([FaLeistungID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaAKZuweiser Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaAKZuweiser', N'column', N'KaAKZuweiserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaAKZuweiser_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'KaAKZuweiser', N'column', N'FaLeistungID'
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
