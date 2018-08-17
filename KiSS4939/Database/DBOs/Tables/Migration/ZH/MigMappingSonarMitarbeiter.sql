CREATE TABLE [dbo].[MigMappingSonarMitarbeiter](
	[SonarMaId] [int] NOT NULL,
	[KissUserID] [int] NULL,
	[LogonName] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_MigMappingSonarMitarbeiter] PRIMARY KEY CLUSTERED 
(
	[SonarMaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON