CREATE TABLE [dbo].[XProfile](
	[XProfileID] [int] IDENTITY(1,1) NOT NULL,
	[XProfileTypeCode] [int] NOT NULL,
	[NameTID] [int] NULL,
	[Name] [varchar](300) NULL,
	[Description] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XProfileTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XProfile] PRIMARY KEY CLUSTERED 
(
	[XProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'XProfileID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typ des Profils. Es gibt Profile für Vorlagen und Profile für Abteilungen und Benutzer.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'XProfileTypeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angezeigter Name des Profils (mehrsprachig). Fremdschlüsssel auf XLangText.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'NameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Interner Name des Profils. Siehe auch NameTID (Name kann in mehrere Sprachen übersetzt werden).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung des Profils. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile', @level2type=N'COLUMN',@level2name=N'XProfileTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ein Profil enthält eine Auswahl an Tags (XProfileTags). So kann man anhand eines Input-Profiles passende andere Profile finden. Zur Zeit nur bei Vorlagen verwendet.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XProfile'
GO

ALTER TABLE [dbo].[XProfile] ADD  CONSTRAINT [DF_XProfile_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XProfile] ADD  CONSTRAINT [DF_XProfile_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


