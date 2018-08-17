CREATE TABLE [dbo].[AlphaCallLog](
	[AlphaCallLogID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime] NULL,
	[Server] [varchar](20) NULL,
	[DatabaseName] [varchar](10) NULL,
	[Query] [varchar](4000) NULL,
	[QueriedTable] [varchar](50) NULL,
	[ElapsedMilliseconds] [int] NULL,
	[ResultTableCount] [int] NULL,
	[CallState] [int] NULL,
	[UserID] [int] NULL,
	[UserWinLogonName] [varchar](30) NULL,
 CONSTRAINT [PK_AlphaCallLog] PRIMARY KEY CLUSTERED 
(
	[AlphaCallLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO
SET ANSI_PADDING ON