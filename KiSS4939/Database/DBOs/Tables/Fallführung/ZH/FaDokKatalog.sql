CREATE TABLE [dbo].[FaDokKatalog](
	[FaDokKatalogID] [int] IDENTITY(1,1) NOT NULL,
	[Kurzbeschreibung] [varchar](100) NULL,
	[Beschreibung] [varchar](999) NULL,
	[SortKey] [int] NULL,
	[FaDokKatalogTS] [timestamp] NOT NULL,
	[FaDokAufbewahrungsdauerCode] [int] NULL,
	[FaDokVisumsberechtigungCode] [int] NULL,
	[Archivwuerdig] [bit] NULL,
	[Fallverlaufeintrag] [bit] NULL,
	[Loeschbar] [bit] NULL,
 CONSTRAINT [PK_FaDokKatalog] PRIMARY KEY CLUSTERED 
(
	[FaDokKatalogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sonst ab Erstelldatum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokKatalog', @level2type=N'COLUMN',@level2name=N'Fallverlaufeintrag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ueberfuehrung in das Stadtarchiv' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokKatalog', @level2type=N'COLUMN',@level2name=N'Loeschbar'