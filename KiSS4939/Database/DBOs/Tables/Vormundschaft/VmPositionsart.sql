CREATE TABLE [dbo].[VmPositionsart](
	[VmPositionsartID] [int] IDENTITY(1,1) NOT NULL,
	[VmKategorieCode] [int] NOT NULL,
	[VmPositionsartTypCode] [int] NULL,
	[IstTemplate] [bit] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SortKey] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmPositionsartTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmPositionsart] PRIMARY KEY CLUSTERED 
(
	[VmPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'VmPositionsartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kategorie in welcher die Positionsart angezeigt werden muss (Vermögen, Einnahmen, Fixe Kosten, Variable Kosten). LOV VmKategorie (auch enum in C# VmKategorie)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'VmKategorieCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zum definieren ob es eine Standardposition ist. Standardpositionen werden beim erfassen eines Klientenbudget erstellt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'IstTemplate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Um die Sortierung den Positionsarten inerhalb einer Kategorie zu definieren' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'SortKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart', @level2type=N'COLUMN',@level2name=N'VmPositionsartTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um Positionsarten zu erfassen. Wird für VmPosition verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPositionsart'
GO

ALTER TABLE [dbo].[VmPositionsart] ADD  CONSTRAINT [DF_VmPositionsart_IstTemplate]  DEFAULT ((0)) FOR [IstTemplate]
GO

ALTER TABLE [dbo].[VmPositionsart] ADD  CONSTRAINT [DF_VmPositionsart_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmPositionsart] ADD  CONSTRAINT [DF_VmPositionsart_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
