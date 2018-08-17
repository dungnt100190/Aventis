﻿CREATE TABLE [dbo].[MigMappingKgKontoOLD](
	[BuchungsTextCode] [int] NULL,
	[BuchungsTextText] [varchar](200) NULL,
	[KiSS-Konto] [int] NOT NULL,
	[lMigMappingKgKontoOLD] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigMappingKgKontoOLD] PRIMARY KEY CLUSTERED 
(
	[lMigMappingKgKontoOLD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON