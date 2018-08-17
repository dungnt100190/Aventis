CREATE TABLE [dbo].[MigMappingUser](
	[MigMappingUserID] [int] IDENTITY(1,1) NOT NULL,
	[Mitarbeiter] [numeric](9, 0) NULL,
	[MAKuerzel] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[LogonName] [varchar](200) NULL,
 CONSTRAINT [PK_MigMappingUser] PRIMARY KEY CLUSTERED 
(
	[MigMappingUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON