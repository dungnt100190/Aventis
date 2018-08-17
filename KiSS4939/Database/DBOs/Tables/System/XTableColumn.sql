CREATE TABLE [dbo].[XTableColumn](
	[TableName] [varchar](255) NOT NULL,
	[ColumnName] [varchar](255) NOT NULL,
	[FieldCode] [int] NULL,
	[DisplayText] [varchar](255) NULL,
	[DisplayTextTID] [int] NULL,
	[LOVName] [varchar](255) NULL,
	[System] [bit] NOT NULL,
	[Comment] [varchar](2000) NULL,
	[SortKey] [int] NULL,
	[XTableColumnTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTableColumn] PRIMARY KEY NONCLUSTERED 
(
	[TableName] ASC,
	[ColumnName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XTableColumn]    Script Date: 04/03/2014 17:54:33 ******/
CREATE CLUSTERED INDEX [IX_XTableColumn] ON [dbo].[XTableColumn] 
(
	[TableName] ASC,
	[SortKey] ASC,
	[ColumnName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XTableColumn Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTableColumn', @level2type=N'COLUMN',@level2name=N'TableName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XTableColumn Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTableColumn', @level2type=N'COLUMN',@level2name=N'ColumnName'
GO

ALTER TABLE [dbo].[XTableColumn]  WITH CHECK ADD  CONSTRAINT [FK_XTableColumn_XTable] FOREIGN KEY([TableName])
REFERENCES [dbo].[XTable] ([TableName])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XTableColumn] CHECK CONSTRAINT [FK_XTableColumn_XTable]
GO

ALTER TABLE [dbo].[XTableColumn] ADD  CONSTRAINT [DF_XTableColumn_System]  DEFAULT ((0)) FOR [System]
GO

