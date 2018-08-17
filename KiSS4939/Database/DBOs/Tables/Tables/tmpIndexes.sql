CREATE TABLE [dbo].[tmpIndexes] (
	[DBName] [varchar] (150) NULL ,
	[Table] [varchar] (150) NULL ,
	[IndexName] [varchar] (150) NULL ,
	[IndexID] [int] NULL ,
	[IndexType] [varchar] (50) NULL ,
	[IsUnique] [bit] NULL ,
	[Columns] [varchar] (300) NULL ,
	[Beschreibung] [varchar] (500) NULL
) ON [PRIMARY]
GO
