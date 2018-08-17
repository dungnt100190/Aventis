CREATE TABLE [dbo].[XNamespaceExtension](
	[XNamespaceExtensionID] [int] IDENTITY(1,1) NOT NULL,
	[NamespaceExtension] [varchar](50) NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XNamespaceExtension_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XNamespaceExtension_Modified]  DEFAULT (getdate()),
	[XNamespaceExtensionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XNamespaceExtension] PRIMARY KEY CLUSTERED 
(
	[XNamespaceExtensionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XNamespaceExtension_NamespaceExtension] UNIQUE NONCLUSTERED 
(
	[NamespaceExtension] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XNamespaceExtension_XNamespaceExtensionID_NamespaceExtension]    Script Date: 01/25/2010 10:46:51 ******/
CREATE NONCLUSTERED INDEX [IX_XNamespaceExtension_XNamespaceExtensionID_NamespaceExtension] ON [dbo].[XNamespaceExtension] 
(
	[XNamespaceExtensionID] ASC,
	[NamespaceExtension] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XNamespaceExtension Records (nach Primärschlüssel-Standards). Eindeutige ID des Namespace-Extension-Eintrags.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'XNamespaceExtensionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace-Extension, welche für die Indentifikation einer spezifischen Implementation verwendet wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'NamespaceExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension', @level2type=N'COLUMN',@level2name=N'XNamespaceExtensionTS'
GO
EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi (erstellt am 25.01.2010)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet alle KiSS Namespace-Extensions' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XNamespaceExtension'