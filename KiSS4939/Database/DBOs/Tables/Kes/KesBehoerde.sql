CREATE TABLE [dbo].[KesBehoerde](
	[KesBehoerdeID] [int] IDENTITY(1,1) NOT NULL,
	[KESBID] [varchar](50) NOT NULL,
	[Kanton] [varchar](10) NOT NULL,
	[KESBName] [varchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesBehoerdeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesBehoerde] PRIMARY KEY CLUSTERED 
(
	[KesBehoerdeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KESB-ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'KESBID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kanton' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'Kanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KESB-Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'KESBName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ist Aktiv ?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'IsActive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde', @level2type=N'COLUMN',@level2name=N'KesBehoerdeTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nathanaël Rossel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KesBehorde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesBehoerde'
GO

ALTER TABLE [dbo].[KesBehoerde] ADD  CONSTRAINT [DF_KesBehoerde_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO

ALTER TABLE [dbo].[KesBehoerde] ADD  CONSTRAINT [DF_KesBehoerde_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesBehoerde] ADD  CONSTRAINT [DF_KesBehoerde_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

