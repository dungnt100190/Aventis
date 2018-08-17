CREATE TABLE [dbo].[XTranslateColumn](
	[XTranslateColumnID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](255) NOT NULL,
	[ColumnName] [varchar](255) NOT NULL,
	[TIDColumnName] [varchar](255) NOT NULL,
	[Description] [varchar](2000) NULL,
	[Creator] [varchar](255) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XTranslateColumn_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](255) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XTranslateColumn_Modified]  DEFAULT (getdate()),
	[XTranslateColumnTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTranslateColumn] PRIMARY KEY CLUSTERED 
(
	[XTranslateColumnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XTranslateColumn_TableName_ColumnName] UNIQUE NONCLUSTERED 
(
	[TableName] ASC,
	[ColumnName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'XTranslateColumnID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Tabelle, welche die zu übersetzende Spalte enthält' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'TableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Spalte, welche den Standard-Text beinhaltet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'ColumnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Spalte, welche für den zugehörigen TID verwendet wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'TIDColumnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung zum Eintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz mutiert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz mutiert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird zur Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTranslateColumn', @level2type=N'COLUMN',@level2name=N'XTranslateColumnTS'