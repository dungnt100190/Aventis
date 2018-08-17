CREATE TABLE [dbo].[XBFsFrage](
	[XBFsFrageID] [int] NOT NULL,
	[VarName] [varchar](10) NULL,
	[Frage] [varchar](200) NULL,
	[DatenTypCode] [int] NULL CONSTRAINT [DF_XBFsFrage_DatenTypCode]  DEFAULT ((1)),
	[Formatierung] [varchar](20) NULL,
	[VarLen] [int] NULL,
	[LOVName] [varchar](100) NULL,
	[ValidierungCode] [int] NULL,
	[BFSDefault] [varchar](100) NULL,
	[MapTabellenName] [varchar](100) NULL,
	[MapFeldName] [varchar](100) NULL,
	[HilfeTitel] [varchar](200) NULL,
	[HilfeText] [text] NULL,
	[SortKey] [int] NULL,
	[XBFsFrageTS] [timestamp] NOT NULL,
	[DataType] [varchar](1000) NULL,
	[UserEdit] [bit] NULL CONSTRAINT [DF__XBFSFrage__UserE__6637AEE1]  DEFAULT ((1)),
	[ExportNode] [varchar](100) NULL,
	[ExportAttribute] [varchar](100) NULL,
	[ExportPredicate] [varchar](100) NULL,
	[SostatKategorieCode] [int] NULL,
	[MapIDFeld] [varchar](100) NULL,
	[MapIDFeldcode] [varchar](100) NULL,
	[FromPart] [varchar](8000) NULL,
	[SubSelect] [varchar](8000) NULL,
	[UE_NR] [int] NULL,
 CONSTRAINT [PK_XBFsFrage] PRIMARY KEY CLUSTERED 
(
	[XBFsFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XBFsFrage_]    Script Date: 11/23/2011 16:43:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_XBFsFrage_] ON [dbo].[XBFsFrage] 
(
	[VarName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]