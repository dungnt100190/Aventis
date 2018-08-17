CREATE TABLE [dbo].[BaPerson_Relation](
	[BaPerson_RelationID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID_1] [int] NOT NULL,
	[BaPersonID_2] [int] NOT NULL,
	[BaRelationID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[BaRelationQualitaetCode] [int] NULL,
	[Bemerkung] [text] NULL,
	[BaPerson_RelationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPerson_Relation] PRIMARY KEY CLUSTERED 
(
	[BaPerson_RelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_BaPerson_Relation_BaPersonID_1]    Script Date: 11/23/2011 10:44:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaPersonID_1] ON [dbo].[BaPerson_Relation] 
(
	[BaPersonID_1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaPerson_Relation_BaPersonID_2]    Script Date: 11/23/2011 10:44:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaPersonID_2] ON [dbo].[BaPerson_Relation] 
(
	[BaPersonID_2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaPerson_Relation_BaRelationID]    Script Date: 11/23/2011 10:44:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaRelationID] ON [dbo].[BaPerson_Relation] 
(
	[BaRelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaPerson_Relation_DatumVon]    Script Date: 11/23/2011 10:44:02 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_DatumVon] ON [dbo].[BaPerson_Relation] 
(
	[DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaPerson] FOREIGN KEY([BaPersonID_1])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaPerson]
GO
ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaPerson1] FOREIGN KEY([BaPersonID_2])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaPerson1]
GO
ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaRelation] FOREIGN KEY([BaRelationID])
REFERENCES [dbo].[BaRelation] ([BaRelationID])
GO
ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaRelation]