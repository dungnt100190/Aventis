CREATE TABLE [dbo].[XBFsFrageNeu](
	[XBFsFrageID] [int] NULL,
	[VarName] [varchar](10) NULL,
	[Frage] [varchar](200) NULL,
	[DatenTypCode] [int] NULL,
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
	[XBFsFrageTS] [timestamp] NULL,
	[DataType] [varchar](15) NULL,
	[UserEdit] [bit] NULL,
	[ExportNode] [varchar](100) NULL,
	[ExportAttribute] [varchar](100) NULL,
	[ExportPredicate] [varchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO