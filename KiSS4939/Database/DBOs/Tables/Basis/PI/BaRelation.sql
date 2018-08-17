CREATE TABLE [dbo].[BaRelation](
	[BaRelationID] [int] NOT NULL,
	[NameRelation] [varchar](100) NOT NULL,
	[NameGenerisch1] [varchar](75) NOT NULL,
	[NameGenerisch1TID] [int] NULL,
	[NameGenerisch2] [varchar](75) NOT NULL,
	[NameGenerisch2TID] [int] NULL,
	[NameMaennlich1] [varchar](75) NOT NULL,
	[NameMaennlich1TID] [int] NULL,
	[NameWeiblich1] [varchar](75) NOT NULL,
	[NameWeiblich1TID] [int] NULL,
	[NameMaennlich2] [varchar](75) NOT NULL,
	[NameMaennlich2TID] [int] NULL,
	[NameWeiblich2] [varchar](75) NOT NULL,
	[NameWeiblich2TID] [int] NULL,
	[symmetrisch] [bit] NOT NULL,
	[SortKey] [int] NOT NULL,
	[BaRelationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaRelation] PRIMARY KEY CLUSTERED 
(
	[BaRelationID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO