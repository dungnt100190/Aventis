CREATE TABLE [dbo].[BaPerson_Relation](
	[BaPerson_RelationID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID_1] [int] NOT NULL,
	[BaPersonID_2] [int] NULL,
	[BaRelationID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[BaPerson_RelationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPerson_Relation] PRIMARY KEY CLUSTERED 
(
	[BaPerson_RelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BaPerson_Relation_BaPersonID_1_BaPersonID_2] UNIQUE NONCLUSTERED 
(
	[BaPersonID_1] ASC,
	[BaPersonID_2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BaPerson_Relation_BaPersonID_2_BaPersonID_1] UNIQUE NONCLUSTERED 
(
	[BaPersonID_2] ASC,
	[BaPersonID_1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaPersonID_2_BaPersonID_1_BaRelationID] ON [dbo].[BaPerson_Relation] 
(
	[BaPersonID_2] ASC,
	[BaPersonID_1] ASC,
	[BaRelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaPerson_ID1] FOREIGN KEY([BaPersonID_1])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaPerson_ID1]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaPerson_ID2] FOREIGN KEY([BaPersonID_2])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaPerson_ID2]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaRelation] FOREIGN KEY([BaRelationID])
REFERENCES [dbo].[BaRelation] ([BaRelationID])
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaRelation]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH NOCHECK ADD  CONSTRAINT [CK_BaPerson_Relation_DataIntegrity] CHECK  (([dbo].[fnBaCKBaPersonRelationIntegrity]([BaPerson_RelationID],[BaPersonID_1],[BaPersonID_2])=(0)))
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [CK_BaPerson_Relation_DataIntegrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for duplicate relations or relation on itself' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'CONSTRAINT',@level2name=N'CK_BaPerson_Relation_DataIntegrity'
GO