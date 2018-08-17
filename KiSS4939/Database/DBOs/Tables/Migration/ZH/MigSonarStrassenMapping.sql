CREATE TABLE [dbo].[MigSonarStrassenMapping](
	[SonarStrasseID] [int] NOT NULL,
	[BaStrasseID] [numeric](4, 0) NOT NULL,
	[StrasseLang] [nvarchar](24) NULL,
	[lMigSonarStrassenMapping] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigSonarStrassenMapping] PRIMARY KEY CLUSTERED 
(
	[lMigSonarStrassenMapping] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
