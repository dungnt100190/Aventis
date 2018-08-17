CREATE TABLE [dbo].[BFSKatalogVersion](
	[BFSKatalogVersionID] [int] NOT NULL,
	[Jahr] [int] NULL,
	[PlausexVersion] [varchar](50) NULL,
	[DossierXML] [varchar](max) NULL,
 CONSTRAINT [PK_BFSKatalogVersion] PRIMARY KEY CLUSTERED 
(
	[BFSKatalogVersionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BFSKatalogVersion Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSKatalogVersion', @level2type=N'COLUMN',@level2name=N'BFSKatalogVersionID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO
