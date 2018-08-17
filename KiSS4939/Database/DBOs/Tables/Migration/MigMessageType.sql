CREATE TABLE [dbo].[MigMessageType](
	[MigMessageTypeID] [int] NOT NULL,
	[MigMessageTypeParentID] [int] NULL,
	[SortKey] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](4000) NULL,
	[DarstellungSQL] [varchar](4000) NULL,
	[SeverityLevel] [int] NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_MigMessageType] PRIMARY KEY CLUSTERED 
(
	[MigMessageTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON