CREATE TABLE [dbo].[MigLookup](
	[Lookup] [varchar](100) NOT NULL,
	[RowID] [int] NOT NULL,
	[Value] [varchar](max) NULL,
	[MigLookupTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_MigLookup] PRIMARY KEY CLUSTERED 
(
	[Lookup] ASC,
	[RowID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLookup', @level2type=N'COLUMN',@level2name=N'MigLookupTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLookup'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lookup-Tabelle für Datenanonymisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLookup'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Anonymisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLookup'
GO

