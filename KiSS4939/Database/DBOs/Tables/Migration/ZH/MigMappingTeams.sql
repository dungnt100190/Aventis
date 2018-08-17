CREATE TABLE [dbo].[MigMappingTeams](
	[AdFirma] [varchar](100) NOT NULL,
	[AdAbteilung] [varchar](100) NOT NULL,
	[OrgUnitID] [int] NULL,
	[OrgUnitName] [varchar](50) NULL,
	[lMigMappingTeams] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigMappingTeams] PRIMARY KEY CLUSTERED 
(
	[lMigMappingTeams] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON