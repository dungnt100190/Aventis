CREATE TABLE [dbo].[MigPerson_Relation](
	[BaPerson_RelationID] [int] IDENTITY(1,1) NOT NULL,
	[ID_1] [int] NOT NULL,
	[ID_2] [int] NOT NULL,
	[BaPersonID_1] [int] NOT NULL,
	[BaPersonID_2] [int] NOT NULL,
	[BaRelationID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[BaRelationQualitaetCode] [int] NULL,
	[Bemerkung] [text] NULL,
	[BaPerson_RelationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_MigPerson_Relation] PRIMARY KEY CLUSTERED 
(
	[BaPerson_RelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_MigPerson_Relation_ID_1_ID_2]    Script Date: 11/23/2011 16:19:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MigPerson_Relation_ID_1_ID_2] ON [dbo].[MigPerson_Relation] 
(
	[ID_1] ASC,
	[ID_2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]