CREATE TABLE [dbo].[BaPerson_Relation](
	[BaPerson_RelationID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID_1] [int] NOT NULL,
	[BaPersonID_2] [int] NOT NULL,
	[BaRelationID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[BaPerson_RelationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPerson_Relation] PRIMARY KEY CLUSTERED 
(
	[BaPerson_RelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaPerson12_Unique] ON [dbo].[BaPerson_Relation] 
(
	[BaPersonID_1] ASC,
	[BaPersonID_2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaPersonID_1] ON [dbo].[BaPerson_Relation] 
(
	[BaPersonID_1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaPersonID_2] ON [dbo].[BaPerson_Relation] 
(
	[BaPersonID_2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaPerson_Relation_BaRelationID] ON [dbo].[BaPerson_Relation] 
(
	[BaRelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaPerson_Relation Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'BaPerson_RelationID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaPerson_Relation_BaPerson1) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'BaPersonID_1'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaPerson_Relation_BaPerson2) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'BaPersonID_2'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaPerson_Relation_BaRelation) => BaRelation.BaRelationID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'BaRelationID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beginn der Relation zwischen Person 1 und Person 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'In Bern nicht verwendet.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Relation zwischen Person 1 und Person 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wird in Bern nicht verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungsfeld, ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'ck: mir ist nicht klar wo das in KiSS4 erfasst werden kann --> löschen?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zur Erfassung einer Beziehung (Relation) zwischen Person 1 und Person 2.    Z.B. Person 1 ist Mutter von Person 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Basis, Fallführung, Sozialhilfe, Asyl, BFS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation'
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaPerson1] FOREIGN KEY([BaPersonID_1])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaPerson1]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaPerson2] FOREIGN KEY([BaPersonID_2])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaPerson2]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_Relation_BaRelation] FOREIGN KEY([BaRelationID])
REFERENCES [dbo].[BaRelation] ([BaRelationID])
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [FK_BaPerson_Relation_BaRelation]
GO

ALTER TABLE [dbo].[BaPerson_Relation]  WITH CHECK ADD  CONSTRAINT [CK_BaPerson_Relation_DataIntegrity] CHECK  (([dbo].[fnBaCKBaPersonRelationIntegrity]([BaPerson_RelationID],[BaPersonID_1],[BaPersonID_2])=(0)))
GO

ALTER TABLE [dbo].[BaPerson_Relation] CHECK CONSTRAINT [CK_BaPerson_Relation_DataIntegrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for duplicate relations or relation on itself' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson_Relation', @level2type=N'CONSTRAINT',@level2name=N'CK_BaPerson_Relation_DataIntegrity'
GO