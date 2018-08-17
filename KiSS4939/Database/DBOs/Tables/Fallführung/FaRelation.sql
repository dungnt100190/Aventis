CREATE TABLE [dbo].[FaRelation](
	[FaRelationID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID1] [int] NOT NULL,
	[FaLeistungID2] [int] NOT NULL,
	[FaRelationTypCode] [int] NOT NULL,
	[CascadeUpdate] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaRelationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaRelation] PRIMARY KEY CLUSTERED 
(
	[FaRelationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_FaRelation_FaLeistungID1] ON [dbo].[FaRelation] 
(
	[FaLeistungID1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_FaRelation_FaLeistungID2] ON [dbo].[FaRelation] 
(
	[FaLeistungID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle FaRelation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'FaRelationID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erste FaLeistungID welche mit FaLeistungID2 zusammenhängt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'FaLeistungID1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zweite FaLeistungID welche mit FaLeistungID1 zusammenhängt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'FaLeistungID2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV welche den Typ des Eintrags definiert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'FaRelationTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True wenn beide FaLeistungen synchron behandelt werden sollen. Z.B. bei Fallzugriff.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'CascadeUpdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation', @level2type=N'COLUMN',@level2name=N'FaRelationTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hier werden die FaLeistungen gespeichert, welche verknüpft werden müssen und z.B. in einem Ordner dargestellt werden (EAF).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaRelation'
GO

ALTER TABLE [dbo].[FaRelation]  WITH CHECK ADD  CONSTRAINT [FK_FaRelation_FaLeistung1] FOREIGN KEY([FaLeistungID1])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaRelation] CHECK CONSTRAINT [FK_FaRelation_FaLeistung1]
GO

ALTER TABLE [dbo].[FaRelation]  WITH CHECK ADD  CONSTRAINT [FK_FaRelation_FaLeistung2] FOREIGN KEY([FaLeistungID2])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaRelation] CHECK CONSTRAINT [FK_FaRelation_FaLeistung2]
GO

ALTER TABLE [dbo].[FaRelation] ADD  CONSTRAINT [DF_FaRelation_CascadeUpdate]  DEFAULT ((0)) FOR [CascadeUpdate]
GO

ALTER TABLE [dbo].[FaRelation] ADD  CONSTRAINT [DF_FaRelation_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaRelation] ADD  CONSTRAINT [DF_FaRelation_Modified]  DEFAULT (getdate()) FOR [Modified]
GO