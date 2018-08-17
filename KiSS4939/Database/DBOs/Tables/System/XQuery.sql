CREATE TABLE [dbo].[XQuery](
	[QueryName] [varchar](100) NOT NULL,
	[ParentReportName] [varchar](100) NULL,
	[QueryCode] [int] NOT NULL,
	[UserText] [varchar](100) NULL,
	[LayoutXML] [varchar](max) NULL,
	[ParameterXML] [varchar](max) NULL,
	[SQLquery] [varchar](max) NULL,
	[ContextForms] [varchar](200) NULL,
	[ReportSortKey] [int] NULL,
	[RelationColumnName] [varchar](100) NULL,
	[System] [bit] NOT NULL,
	[XQueryTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XQuery] PRIMARY KEY NONCLUSTERED 
(
	[QueryName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IXU_XQuery_QueryName] UNIQUE NONCLUSTERED 
(
	[QueryName] ASC,
	[QueryCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XQuery]    Script Date: 06/07/2013 16:42:34 ******/
CREATE CLUSTERED INDEX [IX_XQuery] ON [dbo].[XQuery] 
(
	[ParentReportName] ASC,
	[ReportSortKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XQuery_XQuery) => XQuery.QueryName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XQuery', @level2type=N'COLUMN',@level2name=N'ParentReportName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XQuery_XQuery) => XQuery.QueryCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XQuery', @level2type=N'COLUMN',@level2name=N'QueryCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The column name used to create a relation between two tables, usefull for subreports' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XQuery', @level2type=N'COLUMN',@level2name=N'RelationColumnName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'flag ob der Report System ist oder nicht. System-Reports können nur durch diag_admin geändert werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XQuery', @level2type=N'COLUMN',@level2name=N'System'
GO

ALTER TABLE [dbo].[XQuery]  WITH CHECK ADD  CONSTRAINT [FK_XQuery_XQuery] FOREIGN KEY([ParentReportName], [QueryCode])
REFERENCES [dbo].[XQuery] ([QueryName], [QueryCode])
GO

ALTER TABLE [dbo].[XQuery] CHECK CONSTRAINT [FK_XQuery_XQuery]
GO

ALTER TABLE [dbo].[XQuery] ADD  CONSTRAINT [DF_XQuery_System]  DEFAULT ((1)) FOR [System]
GO


