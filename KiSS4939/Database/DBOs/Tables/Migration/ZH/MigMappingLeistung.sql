﻿CREATE TABLE [dbo].[MigMappingLeistung](
	[Leistung] [int] NOT NULL,
	[FaLeistungID] [int] NULL,
	[FaFallID] [int] NULL,
	[MatchType] [int] NOT NULL,
 CONSTRAINT [PK_MigMappingLeistung] PRIMARY KEY CLUSTERED 
(
	[Leistung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]
