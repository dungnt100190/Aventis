CREATE TABLE [dbo].[BaRelation] (
	[BaRelationID] [int] IDENTITY (1, 1) NOT NULL ,
	[NameRelation] [varchar] (100) NOT NULL ,
	[NameGenerisch1] [varchar] (75) NOT NULL ,
	[NameGenerisch2] [varchar] (75) NOT NULL ,
	[NameMaennlich1] [varchar] (50) NOT NULL ,
	[NameWeiblich1] [varchar] (50) NOT NULL ,
	[NameMaennlich2] [varchar] (50) NOT NULL ,
	[NameWeiblich2] [varchar] (50) NOT NULL ,
	[symmetrisch] [bit] NOT NULL ,
	[BfsCode12] [int] NOT NULL ,
	[BfsCode21] [int] NOT NULL ,
	[SortKey] [int] NOT NULL ,
	[BaRelationTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BaRelation] PRIMARY KEY  Clustered
	(
		[BaRelationID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BaRelation Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BaRelation', N'column', N'BaRelationID'
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
