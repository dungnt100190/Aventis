-- =============================================
-- Script Template
-- =============================================

CREATE TABLE [dbo].[WshKategorie](
	[WshKategorieID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[IstAktiv] [bit] NOT NULL,
	[IstAbzug] [bit] NOT NULL,
	[SortKey] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshKategorieTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshKategorie] PRIMARY KEY CLUSTERED 
(
	[WshKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN',@level2name=N'WshKategorieID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Kategorie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, ob der Datensatz aktiv ist oder nicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'IstAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, ob die Kategorie ein Abzug ist oder nicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'IstAbzug'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sortierung für die Anzeige' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'SortKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)', @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WshKategorie', @level2type=N'COLUMN', @level2name=N'WshKategorieTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Rolf Hesterberg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WshKategorie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die WSH-Kategorien' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WshKategorie'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE' ,@level1name=N'WshKategorie'
GO

ALTER TABLE [dbo].[WshKategorie] ADD  CONSTRAINT [DF_WshKategorie_IstAktiv]  DEFAULT ((0)) FOR [IstAktiv]
GO

ALTER TABLE [dbo].[WshKategorie] ADD  CONSTRAINT [DF_WshKategorie_IstAbzug]  DEFAULT ((0)) FOR [IstAbzug]
GO

ALTER TABLE [dbo].[WshKategorie] ADD  CONSTRAINT [DF_WshKategorie_Created]  DEFAULT (GETDATE()) FOR [Created]
GO

ALTER TABLE [dbo].[WshKategorie] ADD  CONSTRAINT [DF_WshKategorie_Modified]  DEFAULT (GETDATE()) FOR [Modified]
GO
