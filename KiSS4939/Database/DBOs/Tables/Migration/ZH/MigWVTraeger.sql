CREATE TABLE [dbo].[MigWVTraeger](
	[Laufnummer] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[Von] [datetime] NULL,
	[Bis] [datetime] NULL,
	[WVTraeger] [bit] NULL,
	[WVCode] [int] NULL,
	[WVText] [nvarchar](50) NULL,
	[BEDCode] [int] NULL,
 CONSTRAINT [PK_MigWVTraeger] PRIMARY KEY CLUSTERED 
(
	[Laufnummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MigWVTraeger]  WITH CHECK ADD  CONSTRAINT [FK_MigWVTraeger_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[MigWVTraeger] CHECK CONSTRAINT [FK_MigWVTraeger_BaPerson]