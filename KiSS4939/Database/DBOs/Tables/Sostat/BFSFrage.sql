CREATE TABLE [dbo].[BFSFrage](
	[BFSFrageID] [int] IDENTITY(1,1) NOT NULL,
	[BFSKatalogVersionID] [int] NOT NULL,
	[Variable] [varchar](10) NOT NULL,
	[Frage] [varchar](200) NOT NULL,
	[BFSLeistungsfilterCodes] [varchar](50) NULL,
	[BFSPersonCode] [int] NOT NULL,
	[PersonIndex] [int] NOT NULL,
	[BFSFeldCode] [int] NOT NULL,
	[BFSFormat] [varchar](20) NULL,
	[FFLOVName] [varchar](100) NULL,
	[BFSLOVName] [varchar](100) NULL,
	[BFSValidierungCode] [int] NULL,
	[Vorgabewert] [sql_variant] NULL,
	[BFSKategorieCode] [int] NULL,
	[HerkunftCode] [int] NOT NULL,
	[HerkunftBeschreibung] [varchar](max) NULL,
	[HerkunftSQL] [varchar](max) NULL,
	[FFTabelle] [varchar](100) NULL,
	[FFFeld] [varchar](100) NULL,
	[FFPKFeld] [varchar](100) NULL,
	[Editierbar] [bit] NOT NULL,
	[ExportNode] [varchar](100) NULL,
	[ExportAttribute] [varchar](100) NULL,
	[ExportPredicate] [varchar](100) NULL,
	[HilfeTitel] [varchar](200) NULL,
	[HilfeText] [varchar](max) NULL,
	[Reihenfolge] [int] NULL,
	[BFSFrageTS] [timestamp] NOT NULL,
	[FilterRegel] [varchar](500) NULL,
	[UpdateOK] [bit] NULL,
	[VariableAntragsteller] [varchar](10) NULL,
	[VariableExpandiert] [varchar](15) NULL,
 CONSTRAINT [PK_BFSFrage] PRIMARY KEY CLUSTERED 
(
	[BFSFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [UK_BFSKatalogVersionID_Variable_ExportNode_ExportAttribute] UNIQUE NONCLUSTERED 
(
	[BFSKatalogVersionID] ASC,
	[Variable] ASC,
	[ExportNode] ASC,
	[ExportAttribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BFSFrage Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSFrage', @level2type=N'COLUMN',@level2name=N'BFSFrageID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BFSFrage_BFSKatalogVersion) => BFSKatalogVersion.BFSKatalogVersionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFSFrage', @level2type=N'COLUMN',@level2name=N'BFSKatalogVersionID'
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


GO


GO


GO


GO


GO


GO


GO


GO


GO

ALTER TABLE [dbo].[BFSFrage]  WITH CHECK ADD  CONSTRAINT [FK_BFSFrage_BFSKatalogVersion] FOREIGN KEY([BFSKatalogVersionID])
REFERENCES [dbo].[BFSKatalogVersion] ([BFSKatalogVersionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BFSFrage] CHECK CONSTRAINT [FK_BFSFrage_BFSKatalogVersion]
GO

ALTER TABLE [dbo].[BFSFrage] ADD  CONSTRAINT [DF_BFsFrage_Editierbar]  DEFAULT ((1)) FOR [Editierbar]
GO