CREATE TABLE [dbo].[MigLAUmschluesselung](
	[AlteLeistungsart] [int] NOT NULL,
	[KissPositionsart] [int] NULL,
	[Kommentar] [varchar](200) NULL,
 CONSTRAINT [PK_MigLAUmschluesselung] PRIMARY KEY CLUSTERED 
(
	[AlteLeistungsart] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON