CREATE TABLE [dbo].[PscdMahnungLog](
	[PscdMahnungLogID] [int] IDENTITY(1,1) NOT NULL,
	[LAUFD] [varchar](10) NULL,
	[LAUFI] [varchar](10) NULL,
	[OPBEL] [varchar](20) NULL,
	[MAHNS_OLD] [varchar](2) NULL,
	[MAHNS] [varchar](2) NULL,
	[MAHN_FLAG] [varchar](1) NULL,
	[AUSDAT] [varchar](10) NULL,
	[ZAHLBERBIS] [varchar](10) NULL,
	[FUBANAME] [varchar](50) NULL,
	[MANDT] [varchar](50) NULL,
	[OPUPK] [varchar](50) NULL,
	[OPUPW] [varchar](50) NULL,
	[OPUPZ] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[TIMESTAMP] [varchar](50) NULL,
	[Verarbeitet] [bit] NOT NULL CONSTRAINT [DF_PscdMahnungLog_Verarbeitet]  DEFAULT ((0)),
	[ErstelltDatum] [datetime] NOT NULL CONSTRAINT [DF_PscdMahnungLog_ErstelltDatum]  DEFAULT (getdate()),
	[Fehlermeldung] [varchar](300) NULL,
	[TYPE] [varchar](1) NULL,
	[Code] [varchar](5) NULL,
	[Message] [varchar](220) NULL,
 CONSTRAINT [PK_PscdMahnungLog] PRIMARY KEY CLUSTERED 
(
	[PscdMahnungLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON