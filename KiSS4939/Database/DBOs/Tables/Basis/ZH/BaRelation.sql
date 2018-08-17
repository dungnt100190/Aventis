CREATE TABLE [dbo].[BaRelation](
	[BaRelationID] [int] IDENTITY(1,1) NOT NULL,
	[NameRelation] [varchar](100) NOT NULL,
	[NameGenerisch1] [varchar](75) NOT NULL,
	[NameGenerisch2] [varchar](75) NOT NULL,
	[NameMaennlich1] [varchar](50) NOT NULL,
	[NameWeiblich1] [varchar](50) NOT NULL,
	[NameMaennlich2] [varchar](50) NOT NULL,
	[NameWeiblich2] [varchar](50) NOT NULL,
	[symmetrisch] [bit] NOT NULL,
	[SortKey] [int] NOT NULL,
	[BaRelationTS] [timestamp] NOT NULL,
	[AusblendenBeiFallaufnahme] [bit] NOT NULL CONSTRAINT [DF_BaRelation_AusblendenBeiFallaufnahme]  DEFAULT ((0)),
	[BfsCode12] [int] NULL,
	[BfsCode21] [int] NULL,
 CONSTRAINT [PK_BaRelation] PRIMARY KEY CLUSTERED 
(
	[BaRelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON