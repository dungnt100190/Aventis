CREATE TABLE [dbo].[XBookmark](
	[BookmarkName] [varchar](40) NOT NULL,
	[BookmarkNameTID] [int] NULL,
	[Category] [varchar](50) NOT NULL,
	[CategoryTID] [int] NULL,
	[BookmarkCode] [int] NULL,
	[SQL] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[DescriptionTID] [int] NULL,
	[TableName] [varchar](100) NULL,
	[ModulID] [int] NULL,
	[AlwaysVisible] [bit] NOT NULL,
	[System] [bit] NOT NULL,
	[XBookmarkTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XBookmark] PRIMARY KEY CLUSTERED 
(
	[BookmarkName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XBookmark_ModulID]    Script Date: 04/03/2014 16:31:30 ******/
CREATE NONCLUSTERED INDEX [IX_XBookmark_ModulID] ON [dbo].[XBookmark] 
(
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XBookmark Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XBookmark', @level2type=N'COLUMN',@level2name=N'BookmarkName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Moduls, zu welchem die jeweilige Textmarke gehört (wichtig für die Filterung nach lizenzierten Modulen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XBookmark', @level2type=N'COLUMN',@level2name=N'ModulID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum Übersteuern der Sichtbarkeit durch lizenzierte Module, wobei Wert=1 bedeutet, dass die Textmarke immer sichtbar bleibt, auch ohne Lizenz für Modul' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XBookmark', @level2type=N'COLUMN',@level2name=N'AlwaysVisible'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum Festlegen, ob eine Textmarke von BIAG gewartet wird oder vom Kunden erstellt wurde. Dabei gilt: Wert=1 bedeutet, dass die Textmarke von BIAG erstellt und verwaltet wird, Wert=0 bedeutet, dass der Kunde selber für Wartung und Support verantwortlich ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XBookmark', @level2type=N'COLUMN',@level2name=N'System'
GO

ALTER TABLE [dbo].[XBookmark]  WITH CHECK ADD  CONSTRAINT [FK_XBookmark_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XBookmark] CHECK CONSTRAINT [FK_XBookmark_XModul]
GO

ALTER TABLE [dbo].[XBookmark] ADD  CONSTRAINT [DF_XBookmark_AlwaysVisible]  DEFAULT ((0)) FOR [AlwaysVisible]
GO

ALTER TABLE [dbo].[XBookmark] ADD  CONSTRAINT [DF_XBookmark_System]  DEFAULT ((0)) FOR [System]
GO

