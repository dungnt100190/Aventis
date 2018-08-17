CREATE TABLE [dbo].[MigError](
	[MigErrorID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorLevel] [int] NOT NULL,
	[ErrorCode] [int] NULL,
	[Area] [varchar](50) NOT NULL,
	[Message] [varchar](1000) NOT NULL,
	[SourceTableName] [varchar](50) NULL,
	[IDinSourceTable] [int] NULL,
	[SecondID] [int] NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_MigError] PRIMARY KEY CLUSTERED 
(
	[MigErrorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON