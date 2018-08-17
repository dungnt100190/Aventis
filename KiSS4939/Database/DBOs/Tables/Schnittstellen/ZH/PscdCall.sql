CREATE TABLE [dbo].[PscdCall](
	[PscdCallID] [bigint] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime] NULL,
	[ServiceName] [varchar](30) NULL,
	[PrimaryKey] [bigint] NULL,
	[ServiceURL] [varchar](300) NULL,
	[ReturnMsg] [varchar](200) NULL,
	[ElapsedMilliseconds] [int] NULL,
	[ExceptionMsg] [varchar](1000) NULL,
	[UserID] [int] NULL,
	[UserWinLogonName] [varchar](30) NULL,
 CONSTRAINT [PK_PscdCall] PRIMARY KEY CLUSTERED 
(
	[PscdCallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO
SET ANSI_PADDING ON