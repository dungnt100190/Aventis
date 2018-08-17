CREATE TABLE [dbo].[NeufakturierungAbgesetzterMigWVEinzelpostenLog](
	[NeufakturierungAbgesetzterMigWVEinzelpostenLogID] [int] IDENTITY(1,1) NOT NULL,
	[KbWVLaufID] [int] NOT NULL,
	[MigWVEinzelpostenID] [int] NOT NULL,
	[KbWVEinzelpostenID] [int] NULL,
	[Neufakturiert] [bit] NOT NULL,
	[KbWvEinzelpostenStatusCode] [int] NOT NULL,
	[Fehlermeldung] [varchar](2000) NOT NULL,
	[NeufakturierungAbgesetzterMigWVEinzelpostenLogTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_NeufakturierungAbgesetzterMigWVEinzelpostenLog] PRIMARY KEY CLUSTERED 
(
	[NeufakturierungAbgesetzterMigWVEinzelpostenLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[NeufakturierungAbgesetzterMigWVEinzelpostenLog]  WITH CHECK ADD  CONSTRAINT [FK_NeufakturierungAbgesetzterMigWVEinzelpostenLog_KbWVLauf] FOREIGN KEY([KbWVLaufID])
REFERENCES [dbo].[KbWVLauf] ([KbWVLaufID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NeufakturierungAbgesetzterMigWVEinzelpostenLog] CHECK CONSTRAINT [FK_NeufakturierungAbgesetzterMigWVEinzelpostenLog_KbWVLauf]