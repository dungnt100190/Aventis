CREATE TABLE [dbo].[FaPendenzgruppe] (
	[FaPendenzgruppeID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[Beschreibung] [varchar] (500) NULL ,
	[FaPendenzgruppeTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaPendenzgruppe] PRIMARY KEY  Clustered
	(
		[FaPendenzgruppeID]
	)  ON [PRIMARY]
) ON [PRIMARY]
GO
 CREATE  Unique  INDEX [IX_FaPendenzgruppe_Name_Unique] ON [dbo].[FaPendenzgruppe]([Name]) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Prim�rschl�ssel f�r FaPendenzgruppe Records (nach Prim�rschl�ssel-Standards)', N'user', N'dbo', N'table', N'FaPendenzgruppe', N'column', N'FaPendenzgruppeID'
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
