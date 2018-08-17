CREATE TABLE [dbo].[XArchive](
	[ArchiveID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Address] [varchar](max) NULL,
	[SortKey] [int] NOT NULL,
	[Remark] [varchar](max) NULL,
	[XArchiveTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XArchive] PRIMARY KEY NONCLUSTERED 
(
	[ArchiveID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE CLUSTERED INDEX [IX_XArchive] ON [dbo].[XArchive] 
(
	[SortKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XArchive Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XArchive', @level2type=N'COLUMN',@level2name=N'ArchiveID'
GO