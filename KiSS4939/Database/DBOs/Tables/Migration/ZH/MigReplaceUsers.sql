CREATE TABLE [dbo].[MigReplaceUsers](
	[OldLogonName] [varchar](10) NOT NULL,
	[NewLogonName] [varchar](10) NULL,
	[SortKey] [int] NOT NULL CONSTRAINT [DF_MigReplaceUsers_SortKey]  DEFAULT ((1)),
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_MigReplaceUsers] PRIMARY KEY CLUSTERED 
(
	[OldLogonName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON