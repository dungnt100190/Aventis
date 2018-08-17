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
	[HerkunftBeschreibung] [text] NULL,
	[HerkunftSQL] [text] NULL,
	[FFTabelle] [varchar](100) NULL,
	[FFFeld] [varchar](100) NULL,
	[FFPKFeld] [varchar](100) NULL,
	[Editierbar] [bit] NOT NULL CONSTRAINT [DF_BFsFrage_Editierbar]  DEFAULT ((1)),
	[ExportNode] [varchar](100) NULL,
	[ExportAttribute] [varchar](100) NULL,
	[ExportPredicate] [varchar](100) NULL,
	[HilfeTitel] [varchar](200) NULL,
	[HilfeText] [text] NULL,
	[Reihenfolge] [int] NULL,
	[BFSFrageTS] [timestamp] NOT NULL,
	[FilterRegel] [varchar](500) NULL,
	[UpdateOK] [bit] NULL,
	[VariableAntragsteller] [varchar](10) NULL,
	[VariableExpandiert] [varchar](15) NULL,
	[Pos1] [int] NULL,
	[Pos2] [int] NULL,
 CONSTRAINT [PK_BFSFrage] PRIMARY KEY CLUSTERED 
(
	[BFSFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UK_BFSKatalogVersionID_Variable_ExportNode_ExportAttribute] UNIQUE NONCLUSTERED 
(
	[BFSKatalogVersionID] ASC,
	[Variable] ASC,
	[ExportNode] ASC,
	[ExportAttribute] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[BFSFrage]  WITH CHECK ADD  CONSTRAINT [FK_BFSFrage_BFSKatalogVersion] FOREIGN KEY([BFSKatalogVersionID])
REFERENCES [dbo].[BFSKatalogVersion] ([BFSKatalogVersionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BFSFrage] CHECK CONSTRAINT [FK_BFSFrage_BFSKatalogVersion]