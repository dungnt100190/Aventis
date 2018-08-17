CREATE TABLE [dbo].[XProfileTag](
	[XProfileTagID] [int] IDENTITY(1,1) NOT NULL,
	[NameTID] [int] NULL,
	[Name] [varchar](300) NULL,
	[Description] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XProfileTagTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XProfileTag] PRIMARY KEY CLUSTERED 
(
	[XProfileTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfileTagID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teil eines Fremdschlüssels auf XLangText. Der andere Teil ist LanguageCode. Pro Sprache gibt es einen Eintrag in XlangText. Siehe auch Spalte Name.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'NameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name des Merkmals. Kann in mehrere Sprachen übersetzt werden, siehe auch Spalte NameTID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung des Profil-Merkmals.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Optimistic-Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag', @level2type=N'COLUMN',@level2name=N'XProfileTagTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ein XProfileTag ist ein Attribut, welches einem Profil zugeordnet werden kann. Beispiele aus ProInfirmis: Deutsch, Französisch, Italienisch. Bei BSS: z.B. Sozialhilfe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vorlagenverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfileTag'
GO

ALTER TABLE [dbo].[XProfileTag] ADD  CONSTRAINT [DF_XProfileTag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XProfileTag] ADD  CONSTRAINT [DF_XProfileTag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

