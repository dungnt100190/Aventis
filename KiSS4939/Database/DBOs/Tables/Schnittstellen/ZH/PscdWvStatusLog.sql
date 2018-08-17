CREATE TABLE [dbo].[PscdWvStatusLog](
	[PscdWvStatusLogID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](20) NULL,
	[WvEinzelpostenID] [int] NULL,
	[OPBEL] [varchar](50) NULL,
	[FUBANAME] [varchar](50) NULL,
	[TIMESTAMP] [varchar](50) NULL,
	[MANDT] [varchar](50) NULL,
	[OPUPK] [varchar](50) NULL,
	[OPUPW] [varchar](50) NULL,
	[OPUPZ] [varchar](50) NULL,
	[WVSTATUS] [varchar](1) NULL,
	[WvStatusCodeAlt] [int] NULL,
	[WvStatusCodeNeu] [int] NULL,
	[ErstelltDatum] [datetime] NOT NULL CONSTRAINT [DF_PscdWvStatusLog_ErstelltDatum]  DEFAULT (getdate()),
	[Verarbeitet] [bit] NOT NULL CONSTRAINT [DF_PscdWvStatusLog_Verarbeitet]  DEFAULT ((0)),
	[Fehlermeldung] [varchar](300) NULL,
 CONSTRAINT [PK_PscdWvStatusLog] PRIMARY KEY CLUSTERED 
(
	[PscdWvStatusLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON