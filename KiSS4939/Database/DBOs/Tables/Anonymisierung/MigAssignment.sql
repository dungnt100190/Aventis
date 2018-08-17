CREATE TABLE [dbo].[MigAssignment](
	[Lookup] [varchar](100) NOT NULL,
	[OldValue] [varchar](200) NOT NULL,
	[NewValue] [varchar](200) NULL,
	[MigAssignmentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_MigAssignment] PRIMARY KEY CLUSTERED 
(
	[Lookup] ASC,
	[OldValue] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigAssignment', @level2type=N'COLUMN',@level2name=N'MigAssignmentTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigAssignment'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zuweisungstabelle für Datenanonymisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigAssignment'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Anonymisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigAssignment'
GO

