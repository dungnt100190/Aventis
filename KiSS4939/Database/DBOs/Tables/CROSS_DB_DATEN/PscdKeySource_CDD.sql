CREATE TABLE [dbo].[PscdKeySource](
	[DBName] [varchar](50) NOT NULL,
	[KeyName] [varchar](50) NOT NULL,
	[NextID] [bigint] NOT NULL,
	[FirstID] [bigint] NOT NULL,
	[LastID] [bigint] NOT NULL,
	[NumberCategory] [varchar](10) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO