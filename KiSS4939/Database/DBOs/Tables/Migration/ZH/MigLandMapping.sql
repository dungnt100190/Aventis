CREATE TABLE [dbo].[MigLandMapping](
	[KeyOrtLaender] [int] NOT NULL,
	[BaLandCode] [int] NULL,
	[Aktiv] [bit] NOT NULL,
	[ExportDBName] [varchar](100) NULL,
	[BFSCode] [int] NULL,
	[ShortText] [varchar](50) NULL,
	[SAPKey] [varchar](5) NULL,
	[lMigLandMapping] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigLandMapping] PRIMARY KEY CLUSTERED 
(
	[KeyOrtLaender] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON