SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WhGefKategorie](
	[WhGefKategorieID] [int] IDENTITY(1,1) NOT NULL,
	[WhGefKategorieCode] [int] NOT NULL,
	[WhGefKategorieTypCode] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_WhGefKategorie_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_WhGefKategorie_Modified]  DEFAULT (getdate()),
	[WhGefKategorieTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhGefKategorie] PRIMARY KEY CLUSTERED 
(
	[WhGefKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_WhGefKategorie_WhGefKategorieCode] UNIQUE NONCLUSTERED 
(
	[WhGefKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für diese Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'WhGefKategorieID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der GEF-Gruppe. Als LOV und Enum (WhGefKategorie)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'WhGefKategorieCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code vom Typ der GEF-Gruppe (Aufwand, Ertrag, ...). Als LOV und Enum (WhGefKategorieTyp)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'WhGefKategorieTypCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie', @level2type=N'COLUMN',@level2name=N'WhGefKategorieTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die GEF-Kategorien die nötig sind für das Exportieren der Differenzierung Sozialhilferechnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhGefKategorie'