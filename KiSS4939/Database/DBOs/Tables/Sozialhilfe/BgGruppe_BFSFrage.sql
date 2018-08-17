/****** Object:  Table [dbo].[BgGruppe_BFSFrage]    Script Date: 07/30/2010 14:38:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BgGruppe_BFSFrage](
	[BgGruppe_BFSFrageID] [int] IDENTITY(1,1) NOT NULL,
	[BgGruppeCode] [int] NOT NULL,
	[Variable] [varchar](10) NOT NULL,
 CONSTRAINT [PK_BgGruppe_BFSFrage] PRIMARY KEY CLUSTERED 
(
	[BgGruppe_BFSFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel dieser Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgGruppe_BFSFrage', @level2type=N'COLUMN',@level2name=N'BgGruppe_BFSFrageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf LOV ''BgGruppe''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgGruppe_BFSFrage', @level2type=N'COLUMN',@level2name=N'BgGruppeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BFSFrage (KatalogVersion unabhängig, darum auf das Feld Variable und nicht auf BFSFrageID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgGruppe_BFSFrage', @level2type=N'COLUMN',@level2name=N'Variable'
GO


 