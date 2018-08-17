CREATE TABLE [dbo].[MigBAAVArchiv](
	[ArchivNr] [int] NULL,
	[Serie] [nvarchar](255) NULL,
	[Datum] [datetime] NULL,
	[Name_Vorname] [nvarchar](255) NULL,
	[Name] [nvarchar](50) NULL,
	[Vorname] [nvarchar](50) NULL,
	[Heimatort] [nvarchar](255) NULL,
	[Geburt] [datetime] NULL,
	[AV] [nvarchar](5) NULL,
	[lMigBAAVArchiv] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MigBAAVArchiv] PRIMARY KEY CLUSTERED 
(
	[lMigBAAVArchiv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
