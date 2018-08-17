CREATE TABLE [dbo].[KesArtikel](
  [KesArtikelID] [int] IDENTITY(1,1) NOT NULL,
  [CodeKokes] [varchar](7) NOT NULL,
  [Artikel] [varchar](50) NOT NULL,
  [Absatz] [varchar](50) NULL,
  [Ziffer] [varchar](50) NULL,
  [Gesetz] [varchar](50) NOT NULL,
  [Bezeichnung] [varchar](max) NULL,
  [BezeichnungKurz] [varchar](max) NULL,
  [KesMassnahmeTypCode] [int] NOT NULL,
  [IsMassnahmeGebunden] [bit] NOT NULL,
  [DatumVon] [datetime] NULL,
  [DatumBis] [datetime] NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KesArtikelTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesArtikel] PRIMARY KEY CLUSTERED 
(
  [KesArtikelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KesArtikel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'KesArtikelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kokes Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'CodeKokes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Artikel, z.B. 134.3 ZGB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Artikel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Absatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Absatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ziffer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Ziffer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gesetz, z.B. ZGB oder aZGB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Gesetz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Artikel Bezeichnung, z.B.: Neuregelung elterliche Sorge bei geschiedenen Eltern - Zuteilung gemeinsame elterliche Sorge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kurztext der Bezeichnung für die bessere Anzeige auf den Masken' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'BezeichnungKurz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der LOV KesMassnahmeTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'KesMassnahmeTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob der Artikel ein massnahmegebundenes Geschäft beschreibt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'IsMassnahmeGebunden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum ab wann ein Artikel für neue Massnahmen verwendet werden darf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum bis wann ein Artikel für neue Massnahmen verwendet werden darf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'KesArtikelTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'André Wittwer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kes ZGB Artikel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel'
GO

ALTER TABLE [dbo].[KesArtikel] ADD  CONSTRAINT [DF_KesArtikel_IsMassnahmeGebunden]  DEFAULT ((0)) FOR [IsMassnahmeGebunden]
GO

ALTER TABLE [dbo].[KesArtikel] ADD  CONSTRAINT [DF_KesArtikel_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesArtikel] ADD  CONSTRAINT [DF_KesArtikel_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

