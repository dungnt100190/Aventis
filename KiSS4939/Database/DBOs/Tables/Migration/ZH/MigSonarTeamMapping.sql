﻿CREATE TABLE [dbo].[MigSonarTeamMapping](
	[SonarTeamID] [int] NOT NULL,
	[KiSSXOrgUnitID] [int] NULL,
	[lMigSonarTeamMapping] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigSonarTeamMapping] PRIMARY KEY CLUSTERED 
(
	[lMigSonarTeamMapping] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
