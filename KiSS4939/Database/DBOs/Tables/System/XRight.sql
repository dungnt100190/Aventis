CREATE TABLE [dbo].[XRight](
	[RightID] [int] IDENTITY(1,1) NOT NULL,
	[XClassID] [int] NOT NULL,
	[ClassName] [varchar](255) NOT NULL,
	[RightName] [varchar](100) NOT NULL,
	[UserText] [varchar](255) NOT NULL,
	[Description] [varchar](MAX) NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XRightTS] [timestamp] NOT NULL,
CONSTRAINT [PK_XRight] PRIMARY KEY CLUSTERED 
(
	[RightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_XRight_XClassID] ON [dbo].[XRight] 
(
	[XClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_XRight_ClassNameRightID] ON [dbo].[XRight] 
(
	[ClassName] ASC,
	[RightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XRight_ClassNameRightName] ON [dbo].[XRight] 
(
	[ClassName] ASC,
	[RightName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_XRight_RightName_Unique] ON [dbo].[XRight] 
(
	[RightName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'RightID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XRight_XClass) => XClassID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'XClassID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Klassenname' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN', @level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rechtename' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN', @level2name=N'RightName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzerinformationen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN', @level2name=N'UserText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung für Releasenotes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN', @level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRight', @level2type=N'COLUMN',@level2name=N'XRightTS'
GO

ALTER TABLE [dbo].[XRight]  WITH CHECK ADD  CONSTRAINT [FK_XRight_XClass] FOREIGN KEY([XClassID])
REFERENCES [dbo].[XClass] ([XClassID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XRight] CHECK CONSTRAINT [FK_XRight_XClass]
GO

ALTER TABLE [dbo].[XRight]  WITH CHECK ADD  CONSTRAINT [FK_XRight_XClass_ClassName] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[XRight] CHECK CONSTRAINT [FK_XRight_XClass_ClassName]
GO